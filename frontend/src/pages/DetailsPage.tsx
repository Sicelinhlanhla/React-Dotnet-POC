import { useEffect, useState } from "react"
import { apiFetch } from "../api/apiClient"
import type { User } from "../types/User"

export default function DetailsPage() {

  const [user,setUser] = useState<User | null>(null)

  useEffect(()=>{

    apiFetch<User>("/user/me")
      .then(setUser)

  },[])

  if(!user) {
    return <div className="container">Loading...</div>
  }

  return (

    <div className="container">

      <h1>User Details</h1>

      <p><strong>Name:</strong> {user.name}</p>
      <p><strong>Email:</strong> {user.email}</p>
      <p><strong>Joined:</strong> {new Date(user.createdAt).toLocaleDateString()}</p>

    </div>

  )

}
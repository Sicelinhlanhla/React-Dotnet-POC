import { useState } from "react"
import { apiFetch } from "../api/apiClient"

export default function RegisterPage() {

  const [name,setName] = useState("")
  const [email,setEmail] = useState("")
  const [password,setPassword] = useState("")

  async function register() {

    await apiFetch("/auth/register",{
      method:"POST",
      body:JSON.stringify({
        name,
        email,
        password
      })
    })

    alert("User registered")

  }

  return (

    <div className="container">

      <h1>Register</h1>

      <input
        placeholder="Name"
        value={name}
        onChange={e=>setName(e.target.value)}
      />

      <input
        placeholder="Email"
        value={email}
        onChange={e=>setEmail(e.target.value)}
      />

      <input
        placeholder="Password"
        type="password"
        value={password}
        onChange={e=>setPassword(e.target.value)}
      />

      <button onClick={register}>
        Register
      </button>

    </div>

  )

}
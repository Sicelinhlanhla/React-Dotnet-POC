import { useState } from "react"
import { useAuth } from "../auth/authContext"

export default function LoginPage() {

  const { login } = useAuth()

  const [email,setEmail] = useState("")
  const [password,setPassword] = useState("")

  async function handleLogin() {

    await login(email,password)

  }

  return (

    <div className="container">

      <h1>Login</h1>

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

      <button onClick={handleLogin}>
        Login
      </button>

    </div>

  )

}
import { createContext, useContext, useState } from "react"
import { apiFetch } from "../api/apiClient"

interface AuthContextType {
  token: string | null
  login: (email: string, password: string) => Promise<void>
  logout: () => void
}

const AuthContext = createContext<AuthContextType | undefined>(undefined)

export function AuthProvider({ children }: { children: React.ReactNode }) {

  const [token, setToken] = useState<string | null>(
    localStorage.getItem("token")
  )

  async function login(email: string, password: string) {

    const result = await apiFetch<{ token: string }>("/auth/login", {
      method: "POST",
      body: JSON.stringify({
        email,
        password
      })
    })

    localStorage.setItem("token", result.token)
    setToken(result.token)

  }

  function logout() {

    localStorage.removeItem("token")
    setToken(null)

  }

  return (

    <AuthContext.Provider value={{ token, login, logout }}>
      {children}
    </AuthContext.Provider>

  )

}

export function useAuth() {

  const context = useContext(AuthContext)

  if (!context) {
    throw new Error("useAuth must be used within AuthProvider")
  }

  return context

}
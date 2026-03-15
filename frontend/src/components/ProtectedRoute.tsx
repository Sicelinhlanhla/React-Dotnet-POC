import {Navigate} from "react-router-dom"
import type { JSX } from "react/jsx-dev-runtime"
import { useAuth } from "../auth/authContext"

export default function ProtectedRoute({ children }: { children: JSX.Element }) {

  const { token } = useAuth()

  if (!token) {
    return <Navigate to="/login" />
  }

  return children

}
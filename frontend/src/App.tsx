import { BrowserRouter, Routes, Route } from "react-router-dom"
import { AuthProvider} from "./auth/authContext"

import LoginPage from "./pages/LoginPage"
import RegisterPage from "./pages/RegisterPage"
import DetailsPage from "./pages/DetailsPage"
import ProtectedRoute from "./components/ProtectedRoute"

function App() {

  return (

    <AuthProvider>

      <BrowserRouter>

        <Routes>

          <Route path="/login" element={<LoginPage />} />

          <Route path="/register" element={<RegisterPage />} />

          <Route
            path="/details"
            element={
              <ProtectedRoute>
                <DetailsPage />
              </ProtectedRoute>
            }
          />

        </Routes>

      </BrowserRouter>

    </AuthProvider>

  )

}

export default App
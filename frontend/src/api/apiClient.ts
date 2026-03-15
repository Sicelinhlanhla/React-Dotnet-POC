const API_URL = "http://localhost:5000/api"

export async function apiFetch<T>(
  path: string,
  options?: RequestInit
): Promise<T> {

  const token = localStorage.getItem("token")

  const response = await fetch(`${API_URL}${path}`, {
    ...options,
    headers: {
      "Content-Type": "application/json",
      ...(token ? { Authorization: `Bearer ${token}` } : {}),
      ...options?.headers
    }
  })

  if (!response.ok) {
    throw new Error(`API error: ${response.status}`)
  }

  return response.json()

}
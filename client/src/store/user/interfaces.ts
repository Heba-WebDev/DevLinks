export interface userState {
    accessToken: string | null,
    id: string,
    email: string,
    firstName: string | null,
    lastName: string | null,
    image: string | null,
    role: "Admin" | "User" | null,
    username: string
}

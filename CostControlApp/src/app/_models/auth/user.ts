export interface User{
    username: string;
    token: string;
    refreshToken: string;
    firstName: string;
    lastName: string;
    roles: string[];
    email: string;
    birthdate: Date;
    address: string;
    documentId: string;
}
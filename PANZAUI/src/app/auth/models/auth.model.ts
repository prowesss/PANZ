export interface loginCredential{
    username: string;
    password: string;
}

export interface userCredential{
    username?:string,
    token: string,
    expiration: Date
}

export interface userInfo{
    
}

// export interface signupCredentials{
//     message(message: any): unknown;
//     username: string,
//     email: string,
//     password: string,
    
// }
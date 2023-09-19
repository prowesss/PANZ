export interface loginCredential{
    username: string;
    password: string;
}

export interface userCredential{
    username?:string,
    token: string,
    expiration: Date
}

import { BaseModel } from "./base.model";

export interface PaymentMethod extends BaseModel{
    id:string;
    name: string;
    description: string;
}

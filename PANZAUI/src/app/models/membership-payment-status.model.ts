import { BaseModel } from "./base.model";

export interface MembershipPaymentStatus extends BaseModel{
    id:string;
    name: string;
    description: string;
}
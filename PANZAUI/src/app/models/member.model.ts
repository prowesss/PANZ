export interface Member {
    id: string
    userId: string
    email: string
    firstName: string
    lastName: string
    imageUrl: string
    gender: string
    residencyStatus: string
    phone: string
    willingToVolunteer: boolean
    address: string
    suburb: string
    city: string
    companyName: string
    jobTitle: string
    paymentMethodUsed: string
    paymentReference: string
    paymentSessionId: string
    membershipStatus: string
    membershipPaymentStatus: string
    membershipType: string
    startDate: Date
    expireDate: Date
}

export interface CreateMember{
    userId: string
    email: string
    firstName: string
    lastName: string
    imageUrl: string
    gender: string
    residencyStatus: string
    phone: string
    willingToVolunteer: boolean
    address: string
    suburb: string
    city: string
    companyName: string
    jobTitle: string
    paymentMethodId: string
    paymentReference: string
    paymentSessionId: string
    membershipStatusId: string
    membershipPaymentStatusId: string
    membershipTypeId: string
    startDate: Date
    expireDate: Date
}
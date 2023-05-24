interface Lang{
    [index: string]: {
        name: string
        description: string
    }
}
interface Speciality{
    _id: string,
    isSubsepeciality: boolean
    name: string
    lang: Lang
}

export interface Doctor{
    _id: string,
    phoneNumbers: string[],
    emails: string[],
    photo: string,
    summary: string,
    speciality: Speciality[],
    gender: string,
    languages: string[],
    birthday: string,
    otherDocuments: any[],
    experience: any[],
    fullName: string,
    source: string,
    score: number,
    education: any[],
    availablity: any[],
    fullName_fuzzy: string[],
    institutionID_list: any[],
    mainInstitution: any,
    experience_years: number,
}

export interface Doctors{
    success: boolean,
    message: string,
    totalCount: number,
    data: Doctor[]
}
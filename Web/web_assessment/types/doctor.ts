export type DoctorDto = {
    success: boolean;
    message: string;
    totalCount: number;
    data: Doctor[];
}
export type Doctor = {
    _id:                string;
    photo:              string;
    speciality:         Speciality[];
    summary:            string;
    education:          string[];
    email:              string[];
    fullName:           string;
    mainInstitution:    MainInstitution;
}

export type Speciality = {
    _id:             string;
    isSubspeciality: boolean;
    name:            string;
}

export type MainInstitution = {
    institutionName: string;
}
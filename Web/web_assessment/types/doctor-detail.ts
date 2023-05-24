import { Institution } from "./institution";
import { Speciality } from "./speciality";

export interface DoctorDetail {
  _id: string;
  phoneNumbers: string[];
  emails: string[];
  photo: string;
  summary: string;
  speciality: Speciality[];
  experience_years: number;
  institutionID_list: Institution[];
  education: any[];
  gender: string;
  languages: any[];
  birthday: string;
  fullName: string;
  title: string;
}

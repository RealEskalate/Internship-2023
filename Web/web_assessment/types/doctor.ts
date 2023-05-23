export type Doctor = {
        id:string;
        image : string;
        name: string;
        career: string;
        placeOfWork: string;

      
}
export type DoctorDetail = {
        id:string;
        image : string;
        name: string;
        career: string;
        placeOfWork: string;
        About:{
                title:string;
                detail:string;
        }
        Education:{
                title:string;
                detail:string;
        }
        contactInfo:{
                title:string
                phonenumber:string
                email:string
        }
}
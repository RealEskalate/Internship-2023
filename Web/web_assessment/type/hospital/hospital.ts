export default interface Hospital {
  _id: string,
    coverPhoto: string,
    photo: string,
    emails:string[],
    services: Services[],
    institutionName: string,
    summary: string,
    location:{
        type: string,
        coordinates: Number[]
      },
      address: {
        region: string,
        woreda:string,
        zone: string,
        summary: string
      },
      phoneNumbers: string[],
      status: string
      
}

interface Services{
    _id: string;
    title: string;
    description: string;
    lang: {
      am: Language;
    };
}



interface Language  {
    title: string;
    description: string;
  };

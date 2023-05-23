// write type for institutionID_list
//"institutionID_list": [
//   {
//     "_id": "629f129c8373fd1bef2db501",
//     "institutionName": "Addis Cardiac Hospital",
//     "lang": {
//         "am": {
//             "institutionName": "አዲስ የልብ ህክምና ሆስፒታል",
//             "summary": "አዲስ የልብ ሆስፒታል በቦሌ ክ/ከተማ በኢትዮጵያ አየር መንገድ የካርጎ ተርሚናል ፊት ለፊት በሚገኘው በኢትዮጲያ የመጀመሪያው ልዩ የልብና የደም ህክምና ሆስፒታል በመሆኑ ኩራት ይሰማዋል። በ2006 ኤሲኤች የሆስፒታል አገልግሎትን ተቀላቅሎ ዘመናዊ እና የላቀ ምርመራ እና የልብ እና ተያያዥ በሽታዎች ህክምና ዘዴዎችን ለመስጠት።\r\n\r\nልዩ የጤና አጠባበቅ አገልግሎቶችን አገልግሎታችንን ለሚፈልጉ ሁሉ ለማድረስ በሆስፒታል ንግድ ውስጥ ነን። ሰራተኞቻችን ሰፋ ያለ የጤና እንክብካቤ አገልግሎቶችን ለማስተናገድ በደንብ የሰለጠኑ እና ብቁ ናቸው። በሚሊዮኖች የሚቆጠሩ ኢንቨስት በማድረግ፣ ACH ራሱን የላቀ ካት ላብራቶሪ እና ሌሎች የቅርብ ጊዜ የህክምና መሳሪያዎችን አስታጥቋል።\r\n\r\nሁሉም ታካሚዎቻችን ሆስፒታላችንን ሲጎበኙ የመጀመሪያ ደረጃ ህክምና እንዲያገኙ እየሰራን ነው። አዲስ የሆስፒታል አስተዳደር ስርዓት (ኤችአርኤም) ተክለናል ይህም ሁሉንም ስራዎችን በየደረጃው ቅልጥፍናን በአግባቡ እንድንቆጣጠር ያስችለናል ።ኤሲኤች በኢትዮጵያ እና በስዊድን ባለአክሲዮኖች ባለቤትነት የተያዘ ሲሆን ከባለድርሻዎቹ አንዱ እና የቦርድ ሰብሳቢ ዶ/ር ፍቁ ማሩ ከፍተኛ ብቃት ያለው የልብ ሐኪም በስዊድን ተምሮ ከ20 አመት በላይ በልብ ሐኪምነት ሰርቷል።",
//             "address": {
//                 "region": "አዲስ አበባ",
//                 "summary": "ቦሌ ክ/ከተማ አዲስ አበባ ኤርፖርት ጭነት ፊት ለፊት",
//                 "woreda": "01",
//                 "zone": "01"
//             },
//             "institutionName_fuzzy": [
//                 "አዲስ",
//                 "የልብ",
//                 "ህክም",
//                 "ህክምና",
//                 "ሆስፒ",
//                 "ሆስፒታ",
//                 "ሆስፒታል",
//                 "አዲስ የልብ ህክምና ሆስፒታል"
//             ]
//         }
//     }
// }
// ],


export interface institutionID_list {
  _id: string;
  institutionName: string;
  lang: {
    am: {
      institutionName: string;
      summary: string;
    };
  };
  address: {
    region: string;
    summary: string;
    woreda: string;
    zone: string;
  };
  institutionName_fuzzy: string[];
}


export interface Speciality {
  _id: string;
  isSubspeciality: boolean;
  name: string;
  lang: {
    am: {
      name: string;
      description: string;
    };
  };
}

export default interface Education {
  _id: string;
  degree: string;
  institutionName: string;
  lang: {
    am: {
      degree: string;
      institutionName: string;
    };
  };
}

export interface Doctor {
  _id: string;
  phoneNumbers: string[];
  emails: string[];
  photo: string;
  summary: string;
  speciality: Speciality[];
  education: Education[];
  institutionID_list: institutionID_list[];
  fullName: string;
}

export interface DoctorListss {
  data: Doctor[];
}

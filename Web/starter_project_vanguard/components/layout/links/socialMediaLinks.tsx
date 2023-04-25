import { FaFacebook, FaInstagram, FaLinkedin,FaTwitter,FaYoutube} from 'react-icons/fa'

interface iconLink {
    icon: any
    url : string
  }
  
  export const socialMedialinks : iconLink[] = [

    {
        icon: <FaTwitter />,
        url: "https://twitter.com/A2_SV"
    },
    {
        icon: <FaFacebook />,
        url: "https://www.facebook.com/profile.php?id=100085473798621"
    },    
    {
        icon: <FaYoutube />,
        url: "https://www.youtube.com/channel/UC70kFW6mFFGEjsucvNZk6-A"
    },
    {
        icon: <FaLinkedin />,
        url: "https://www.linkedin.com/company/a2sv/mycompany/"
    },
    {
        icon: <FaInstagram />,
        url: "https://www.instagram.com/a2sv_org"
    },
    
]
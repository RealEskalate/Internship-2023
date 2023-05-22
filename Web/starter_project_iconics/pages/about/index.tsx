import AboutSection from "@/components/about/AboutSection"
import Cards from "@/components/about/A2svSessionCards"
import ProblemSection from "@/components/about/ProblemSection"
import SessionSection from "@/components/about/SessionSection"
import SocialProjectsSections from "@/components/about/SocialProjectsSections"


const about:React.FC = () => {
    return (
      <>
        <AboutSection/>
        <ProblemSection/>
        <SessionSection/>
        <SocialProjectsSections/>
        <Cards/>
      </>
    )
}


export default about
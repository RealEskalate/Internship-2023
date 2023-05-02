import AboutSection from "@/components/about/AboutSection"
import Card from "@/components/about/Card"
import ProblemSection from "@/components/about/ProblemSection"
import SessionSection from "@/components/about/SessionSection"
import SocialProjectsSections from "@/components/about/SocialProjectsSections"
const about = () => {
    return (
      <>
        <AboutSection/>
        <ProblemSection/>
        <SessionSection/>
        <SocialProjectsSections/>
        <Card/>
      </>
    )
}


export default about
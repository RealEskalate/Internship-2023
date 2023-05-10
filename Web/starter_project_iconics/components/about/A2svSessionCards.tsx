import CardItem from "@/components/about/A2svSessionCardItem"
import cardsData from "../../data/about/about-card.json";


const Cards = () => {

return <section className="grid grid-cols-3 grid-rows-2 px-12">
    {cardsData.map(({logo, title, description}) => {
        return <CardItem title={title} logo = {logo} description = {description} />
    })}
    </section> 
}

export default Cards;
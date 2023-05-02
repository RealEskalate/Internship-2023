import Image from "next/image"

const Carditems = (props: any) => {
    return (
        <>
        <li className="cardss_item bg-white font-poppins text-black flex-auto lg p-12">
            <Image src = {props.logo} alt = "Travrel Image"  width = {100} height = {100} className="cards__item__img"/>
            <h4 className="cards__item__h4 font-normal text-2xl ml-8">{props.title}</h4>
            <p className="cards__item__p font-poppins font-light text-1xl ml-8">{props.description}</p>

        </li>
        </>
    )
}

export default Carditems
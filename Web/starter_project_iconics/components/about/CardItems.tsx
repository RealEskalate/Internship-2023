

const Carditems = (props: any) => {
    return (
        <>
        <li className="cardss_item">
            <img src = {props.logo} alt = "Travrel Image"  className="cards__item__img"/>
            <h4 className="cards__item__h4">{props.title}</h4>
            <p className="cards__item__p">{props.description}</p>

        </li>
        </>
    )
}

export default Carditems
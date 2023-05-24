import React from "react"

interface props {
    photo: string,
    name: string,
    field: string,
    description: string,
}

function CardItem({photo, name, field, description}:props) {
    return (
        <div className = "card flex flex-col border border-gray-300 rounded-3xl overflow-hidden shadow-md bg-white m-2">
            <div className = "img flex flex-auto items-center">
                <img>
                src = {photo} alt = {name}
                </img>
            </div>
            <div className = "name">
                <span>
                <h1>
                {name}
                </h1>
                </span>
            </div>

            <div className = "field">
                <span>
                <h1>
                {field}
                </h1>
                </span>
            </div>

            <div className = "work-description">
                <p>
                {description}
                </p>
            </div>

        </div>

    )
}

export default CardItem
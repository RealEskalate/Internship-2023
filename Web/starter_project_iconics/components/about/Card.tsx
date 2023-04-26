
import logo from '../../public/about/Ellipse-4.png';
import Carditems from "./CardItems";


function Cards() {
    return (
        <div className="cards">
            <div className="cards__container">
                <div className="cards__wrapper">
                    <ul className="cards__items">
                        <div className="card__item">
                            <Carditems 
                            logo = {logo}
                            description = 'Contests help us to get better at competitive programming and problem-solving. We use online platforms like Leetcode and Codeforces.'
                            title = 'Bi-weekly contests'
                            />
                        </div>

                        <div className="card__item">
                            <Carditems 
                            logo = '/public/images/Ellipse 4.png'
                            description = '6 days a week, 3 hours of lectures and practice sessions to improve technical problem-solving skills.'
                            title = 'Technical Training'
                            />
                        </div>

                        <div className="card__item">
                            <Carditems 
                            logo = '/public/images/Ellipse 4.png'
                            description = 'In Q&As, we get to know engineers, founders, and entrepreneurs from top tech companies. We see that they are normal people like us and we learn the best practices.'
                            title = 'Q&As'
                            />
                        </div>

                        <div className="card__item">
                            <Carditems 
                            logo = '/public/images/Ellipse 4.png'
                            description = 'We solve technical problems on a whiteboard while explaining to the class. It helps to get a feel of an interview environment.'
                            title = 'Problem Solving Sessions'
                            />
                        </div>

                        <div className="card__item">
                            <Carditems 
                            logo = '/public/images/Ellipse 4.png'
                            description = 'Students observe how an experienced problem solver approaches a problem from understanding it to implementing a working solution.'
                            title = 'Learning How To Approach'
                            />
                        </div>

                        <div className="card__item">
                            <Carditems 
                            logo = '/public/images/Ellipse 4.png'
                            description = 'In 1:1s, we can talk about anything that matters; clearly no boundaries. The more we speak our minds without a filter, the better for the team.'
                            title = 'Bi-weekly 1:1s'
                            />
                        </div>

                
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default Cards;
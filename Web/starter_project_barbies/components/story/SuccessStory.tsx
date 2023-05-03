import SuccessStoryCard from './SuccessStoryCard'
import style from "./../../styles/story/style.module.css"
import story from "./../../public/data/story.json"
import {SuccessStoriesProps} from './../../types/story'

const SuccessStory = () => {
  return (
    <div className={style.container }>
      {story.map((success: SuccessStoriesProps, index: number) => {
        return <SuccessStoryCard key={index} successStory={success} />;
      })}
    </div>
  )
}

export default SuccessStory



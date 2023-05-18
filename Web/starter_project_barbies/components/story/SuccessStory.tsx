import { Story } from '@/types/story'
import { useGetStoriesQuery } from './../../store/story/story-api'
import style from './../../styles/story/style.module.css'
import SuccessStoryCard from './SuccessStoryCard'

const SuccessStory = () => {
  const { data: successStories, isError, isLoading } = useGetStoriesQuery()

  if (isError) {
    return <div>Error: {isError.toString()}</div>
  }

  if (successStories === undefined || isLoading) {
    return <div>Loading...</div>
  }

  return (
    <div className={style.container}>
      {successStories.map((successStory: Story, index: number) => (
        <SuccessStoryCard key={index} successStory={successStory} />
      ))}
    </div>
  )
}

export default SuccessStory

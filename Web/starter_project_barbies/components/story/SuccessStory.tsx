import SuccessStoryCard from './SuccessStoryCard'
import style from "./../../styles/story/style.module.css"
import { useGetStoriesQuery } from './../../store/story/storys-api'
import { Story } from '@/types/story'

const SuccessStory = () => {
const { data: successStories, isError, isLoading } = useGetStoriesQuery();
  if (isError) {
    return <div>Error: {isError.toString()}</div>;
  }

  if (successStories === undefined || isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div className={style.container}>
      {successStories.map((successStory: Story ,index:number) => (
        <SuccessStoryCard key={index} successStory={successStory} />
      ))}
    </div>
  );
};

export default SuccessStory;
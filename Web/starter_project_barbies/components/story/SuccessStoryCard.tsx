import Image from 'next/image';
import { Story } from './../../types/story';

interface Props {
  successStory: Story;
}

const SuccessStoryCard = (props: Props) => {
const { successStory } = props;
const paragraphs = [
  {
    title: 'My A2SV Experience',
    detail: successStory?.experience,
  },
  {
    title: 'What I did/I am doing now',
    detail: successStory?.achivements, // fixed typo in property name
  },
  {
    title: 'How the A2sv Program changed my life',
    detail: successStory?.a2svImpact,
  },
];

const { image, name, profession, internPlace } = successStory || {};

return (
  <div className="flex flex-row md:gap-5 gap-20 mx-20 my-10">
    <div className="relative flex flex-col w-96 h-100">
      <Image width={400} height={100} src={image} alt={name} priority />
      <div className="absolute flex flex-col gap-2 w-full bottom-0 p-8 rounded-lg shadow-lg backdrop-filter backdrop-blur-lg backdrop-opacity-100 text-white">
        <p className="text-2xl font-semibold">{name}</p>
        <p className="font-semibold">{profession}</p>
        <p>{internPlace}</p>
      </div>
    </div>

    <div className="flex flex-grow flex-col w-64 h-40 gap-30 mx-10 md:w-96 mt-20 lg:mt-10 md:mt-0 ">
      {paragraphs.map((paragraph, index: number) => {
        return (
          <div className="flex flex-col gap-3 mt-5" key={index}>
            <h4 className="font-Montserrat font-medium text-1xl ">{paragraph.title}</h4>
            <p className="text-xs text-secondarytext">{paragraph?.detail}</p>
          </div>
        );
      })}
    </div>
  </div>
);
};

export default SuccessStoryCard;
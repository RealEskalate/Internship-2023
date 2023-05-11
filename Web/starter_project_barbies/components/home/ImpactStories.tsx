import React , {useState} from 'react'
import Image from 'next/image'
import impactStories from "../../public/data/home/impact-stories.json"
import { ImpactStory } from '@/types/home'
function ImpactStories() {
  const [storyHolder , setstoryHolder] = useState<ImpactStory>(impactStories[0])
  const storyHolderFilter = (id:number) =>{
    const [filteredstoryHolder] = impactStories.filter(storyHolder => storyHolder.id == id)
    setstoryHolder(filteredstoryHolder)

  }
  return (
    <div>
        <div className=' p-12 pt-40'>
        <h1 className='capitalize text-5xl font-bold w-fit m-auto justify-between pb-8'>Impact stories</h1>
        <div className='flex gap-10 items-center justify-between'>
          <div>
            <h1 className='font-bold capitalize'>{storyHolder.name}</h1>
            <p className='capitalize pb-12'>{storyHolder.position}</p>
            <p className='max-w-xl'>{storyHolder.description}
            </p>
            <button className=' mt-10 py-2 px-6 bg-primary rounded text-white'>see more</button>
          </div>
          <div>
          <div className='grid grid-cols-3 gap-3 '>
            <div>
            </div>
            <div className='w-44 h-52 relative'>
            <Image fill alt='impact storyHolder image' src={impactStories[0].image} onClick={() => storyHolderFilter(impactStories[0].id)} ></Image>
            </div>
            <div>
            </div>
            {
              impactStories.map((story, index) =>{
                if (index != 0 ){
                  return (
                    <div key={story.id}  className={index % 3 == 2 ? 'w-44 h-52   relative':'h-52 w-44 -mt-28 relative'}>
                    <Image  fill alt='impact storyHolder image' src={impactStories[index].image} onClick={() => storyHolderFilter(impactStories[index].id)} ></Image>
                    </div>
                    )
                } 
              })
            }
          </div>
          </div>
        </div>
      </div> 
    </div>
  )
}

export default ImpactStories
import Image from 'next/image'

function A2SVSession({ image, title, content }: any) {
  return (
    <div className="shadow-lg rounded p-5 m-3">
      <Image src={image} className="w-[60px]" alt={''}></Image>
      <p className="font-bold my-3 text-2xl">{title}</p>
      <p>{content}</p>
    </div>
  )
}

export default A2SVSession

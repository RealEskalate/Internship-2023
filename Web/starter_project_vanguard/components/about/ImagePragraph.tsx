import Image from 'next/image'

function ImagePragraph({ image, text }: any) {
  return (
    <div className="py-7">
      <Image src={image} alt={''} className="w-[7%]"></Image>
      <p className="pt-5">{text}</p>
    </div>
  )
}

export default ImagePragraph

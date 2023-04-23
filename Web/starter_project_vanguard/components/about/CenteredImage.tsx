import Image from 'next/image'

function CenteredImage({ image }: any) {
  return (
    <div className="mx-10 p-10 my-auto">
      <Image src={image} alt={''}></Image>
    </div>
  )
}

export default CenteredImage

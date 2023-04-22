import Image from 'next/image'

function CenteredImage({ image }: any) {
  return (
    <div className="m-10 p-10">
      <Image src={image} alt={''}></Image>
    </div>
  )
}

export default CenteredImage

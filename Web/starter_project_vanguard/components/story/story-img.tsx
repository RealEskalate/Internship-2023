const SucessImage = ({
  name: name,
  image: image,
  category,
  location,
}: {
  name: string
  image: string
  category: string
  location: string
}) => {
  return (
    <div className="relative inline-block sm:max-w-md md:max-w-md lg:w-auto">
      <img src={image} alt={name} />
      <div className="absolute bottom-0 left-0 right-0 backdrop-filter backdrop-blur-md rounded-xl w-full z-10">
        {/* Container for h1, h2, h2 components */}
        <div className=" lg:m-2 lg:py-2">
          <h1 className="lg:pt-4 px-4 font-poppins text-2xl font-bold text-gray-50 ">
            {name}
          </h1>
          <h2 className=" px-4 py-2 font-poppins text-xl font-semibold text-gray-50">
            {category}
          </h2>
          <h2 className="px-4 pb-4 font-poppins text-xl text-gray-50">
            {location}
          </h2>
        </div>
      </div>
    </div>
  )
}

export default SucessImage

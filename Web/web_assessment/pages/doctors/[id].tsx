import { useGetDoctorQuery } from '@/store/features/doctors/doctor-api'
import React from 'react'
import Image from 'next/image'
import router from 'next/router'

const DoctorDetailPage = () => {
    const { id } = router.query as { id: string}
    const { data: doctor, isLoading , isSuccess, isError, error} = useGetDoctorQuery(id)


    if (isLoading){
      return <div>Loading...</div>
    } else if (error || !doctor || !isSuccess || isError) {
      return <div>Error doctorLength:{doctor} error:{error ? error.toString() : ""}</div>
    }
  return (
    <div className='flex flex-col items-center w-9/12 px-8'>
        <Image
          src={doctor.photo}
          alt="a2sv-logo"
          className='rounded-full border-2'
          width={70}
          height={70}
          unoptimized
        />
        <div className='flex flex-row justify-between w-full gap-y-2'>
            <div className='flex flex-col'>
            <h3 className="text-lg font-semibold text-black">
          {doctor.fullName}
        </h3>
        <div className='text-navbar-text'>{doctor.specialty && doctor.speciality.length ? doctor.specialty[0].name : 'Cardiologist'}</div>
            </div>
            <div className='flex flex-col'>
            <p className='text-navbar-text text-sm'>{doctor.education && doctor.education.length ? doctor.education[0].name : "Addis Ababa University"}</p>
            <div className='text-navbar-text'>{doctor.specialty && doctor.speciality.length ? doctor.specialty[0].name : 'Cardiologist'}</div>
            </div>
        </div>

        <div className='flex flex-col'>
            <h3>About</h3>
            <p>{doctor.summary ? doctor.summary : "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis pellentesque purus sit amet mi aliquam, id dictum augue vulputate. Pellentesque porta, ligula non pulvinar sollicitudin, dolor nunc molestie dui, sit amet volutpat eros nibh vitae magna. Nullam tempor, purus nec rutrum varius, arcu massa scelerisque diam, nec vestibulum diam neque a massa. Mauris tempor odio in ornare cursus. Maecenas in ultricies sapien. Suspendisse dolor turpis, pretium vitae lacus eget, condimentum aliquam diam."}</p>
        </div>

        <div className='flex flex-col'>
        <h3>Education</h3>
        {/* {doctor.education.map((education: any) => {
            return (
                <div key={education.id} className='flex flex-col justify-between w-full'>
                    <div className='flex flex-row'>
                    <p className='text-navbar-text text-sm'>{education.name}</p>
                    <div className='text-navbar-text'>{education.name}</div>
                    </div>
                    <div className='flex flex-col'>
                    <p className='text-navbar-text text-sm'>{education.year}</p>
                    </div>
                </div>
            )
        })} */}
        </div>

        <div className='flex flex-col'>
        <h3>Contact Info</h3>
        </div>
    </div>
  )
}

export default DoctorDetailPage
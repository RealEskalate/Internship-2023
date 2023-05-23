// this is the page which will render the doctors list
// in this page we will use the DoctorList component
// I want to add search functionality to this page
// and I want to add pagination to this page


import DoctorList from '@/components/doctors/DoctorList'
import React from 'react'

const DoctorsPage = () => {
  return (
    <DoctorList />
  )
}

export default DoctorsPage
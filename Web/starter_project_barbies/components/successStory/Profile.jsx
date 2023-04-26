import React from 'react'
import ProfileCard from './ProfileCard'
import profiles from './ProfileDataSets'
const Profile = () => {
  return (
    <div className = "flex flex-col mx-10 my-10 gap-10 Profile-container">
        {profiles.map((personalProfile , index)=>
        
        {
            return <ProfileCard key = {index} personalProfile = {personalProfile}/>;
        })}
      
    </div>
  )
}

export default Profile

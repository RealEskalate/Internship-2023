import Text from '@/components/common/Text'
import 'tailwindcss/base.css'
import React, { FC, useState } from 'react'
import Avatar from '../common/Avatar'
import "typeface-montserrat";

type MyTagProps = {
  tags: string[]
}

const Tags: FC<MyTagProps> = ({ tags }) => {
  return (
    <div className="flex flex-wrap justify-start items-end">
      {tags.map((tag, index) => (
        <Chip key={index} label={tag} />
      ))}
    </div>
  )
}

function Description() {
  return (
    <div className="pt-4 w-2/3">
      <Text
        children={
          'Lorem ipsum dolor sit amLorem ipsum dolor sit amet consectetur Lorem ipsum dolor sit amet consectetur Lorem ipsum dolor sit amet consectetur et consectetur adipisicing elit. Blanditiis id deserunt dolor.'
        }
        color="gray-500"
        weight="light"
        size="lg"
      />
    </div>
  )
}

interface ImageProps {
  src: string
  borderRadius?: string
  className?: string
}

const Image: React.FC<ImageProps> = ({
  src,
  borderRadius = 'rounded',
  className,
}) => {
  return (
    <div className={className}>
      <img src={src} className={`object-cover ${borderRadius}`} />
    </div>
  )
}

function Name() {
  return (
    <div className=" flex flex-col justify-center">
      <Text
        size="sm"
        family="montserrat"
        children={'Yididya Kebede'}
        color="black"
        weight="semibold"
        className="block"
      ></Text>

      <Text
        size="sm"
        family="montserrat"
        children={'SOFTWARE ENGINEER'}
        color="gray-500"
        className="flex "
      />
    </div>
  )
}

function ProfilePic() {
  return (
    <div>
      <Avatar
        src="https://media.wired.com/photos/598e35fb99d76447c4eb1f28/16:9/w_2123,h_1194,c_limit/phonepicutres-TA.jpg"
        alt="Avatar"
        size="md"
      />
    </div>
  )
}

type ChipProps = {
  label: string
}

const Chip: FC<ChipProps> = ({ label }) => {
  return (
    <div className="flex items-center px-4 py-2 rounded-full bg-gray-200 text-gray-400 mr-2 mb-2 mx-4 mt-5 ">
      <div className="text-md font-normal">{label}</div>
    </div>
  )
}

function Title() {
  return (
    <div>
      {/* <Text size="2xl" family="montserrat" children={'Yididya Kebede'} color="black"></Text> */}

      <Text
        size="2xl"
        children={'The essential guide to Competitive Programming, '}
        weight="bold"
      />
      <br />
      <Text
        size="2xl"
        children={'Tab System On React : 3 ways to do it.'}
        weight="bold"
      />
    </div>
  )
}

function Blog() {
  return (
    <div className=" flex flex-wrap justify-center w-6/5 ">
      <div className="flex border-t-2  w-3/4 border-gray-300 pl-10">
        <div className=" items-start w-3/5 pt-4 pb-4 pr-0">
          <div className="flex items-start">
            <div className="items-start my-4 mx-0">
              {' '}
              <ProfilePic />{' '}
            </div>
            <div className="self-center mx-3">
              {' '}
              <Name />{' '}
            </div>
            <div className="items-end self-center mx-5">
              <Text
                size="sm"
                family="montserrat"
                children={'April 20'}
                color="black"
                weight="light"
              ></Text>
            </div>
          </div>

          <div className="flex flex-wrap">
            <div>
              {' '}
              <Title />{' '}
            </div>
            <div>
              {' '}
              <Description />{' '}
            </div>
          </div>
          <div className="justify-start items-end">
            <Tags tags={['Development', 'UI/UX']} />
          </div>
        </div>

        <div className="flex justify-center items-center w-1/4 pl-0 ">
          <Image
            className="w-6/5"
            src="https://cdn.pixabay.com/photo/2021/08/04/13/06/software-developer-6521720_960_720.jpg"
            borderRadius="rounded-lg"
          />
        </div>
      </div>
    </div>
  )
}

export default Blog

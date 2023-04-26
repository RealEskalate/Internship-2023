import clsx from 'clsx'

export interface ButtonProps extends React.ComponentProps<'button'> {

  /**
   * Content of the button
   */
  label: string
  /**
   * Classes to modify the button
   */
  className?: string
  /**
   * Optional click handler
   */
  onClick?: () => void

  // optional icon preceding text
  endIcon?: JSX.Element

  // optional trailing icon
  startIcon?: JSX.Element

  // add outline border
  outline?: boolean
}

function Button({ label,
  className, startIcon, endIcon, outline,
  ...props }: ButtonProps){
  return (

    <button {...props} className={clsx( outline? 'outline outline-2 outline-primary text-primary  bg-secondary hover:bg-primary hover:text-secondary' : 'text-secondary bg-primary', 'flex justify-center items-center gap-x-3 px-8 py-3 m-2 text-md  rounded-md cursor-pointer', className)}>{startIcon && startIcon} {label} {endIcon && endIcon} </button>

  )
}

export default Button
import "package:flutter/material.dart";

class Button extends StatelessWidget {
  const Button({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      width: Width * 0.8,
      height: (56 / 812) * Height,
      decoration: BoxDecoration(
        color: Color(0xFF376AED),
        borderRadius: BorderRadius.circular((20 / 812) * Height),
      ),
      child: Center(
        child: Text(
          'SIGNUP',
          style: TextStyle(
            fontFamily: 'Urbanist',
            fontWeight: FontWeight.w700,
            fontSize: (18 / 812) * Height,
            color: Color(0xFFFFFFFF),
            letterSpacing: 1.5,
          ),
        ),
      ),
    );
  }
}

import "package:flutter/material.dart";

class Button extends StatelessWidget {
  const Button({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width * 0.8,
      height: (56 / 812) * MediaQuery.of(context).size.height,
      decoration: BoxDecoration(
        color: Color(0xFF376AED),
        borderRadius: BorderRadius.circular(20),
      ),
      child: Center(
        child: Text(
          'SIGNUP',
          style: TextStyle(
            fontFamily: 'Urbanist',
            fontWeight: FontWeight.w700,
            fontSize: (18 / 812) * MediaQuery.of(context).size.height,
            color: Color(0xFFFFFFFF),
            letterSpacing: 1.5,
          ),
        ),
      ),
    );
  }
}

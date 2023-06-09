import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/global_variables.dart';

class RoundedButton extends StatelessWidget {
  final double width;
  final double height;

  final Function()? pressed;

  const RoundedButton(
      {Key? key,
      required this.width,
      required this.height,
      required this.pressed})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return ElevatedButton(
      onPressed: pressed,
      style: ButtonStyle(
        minimumSize:
            MaterialStateProperty.all(Size(width * 0.46, height * 0.074)),
        backgroundColor: MaterialStateProperty.all(primaryColor),
        textStyle: MaterialStateProperty.all(
          const TextStyle(color: whiteColor),
        ),
        shape: MaterialStateProperty.all(
            RoundedRectangleBorder(borderRadius: BorderRadius.circular(12))),
      ),
      child: const Text(
        'LOGIN',
        style:
            TextStyle(color: whiteColor, fontSize: 20, fontFamily: 'Urbanist'),
      ),
    );
  }
}

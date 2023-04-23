import 'package:flutter/material.dart';

class HeaderText extends StatelessWidget {
  final String text;
  const HeaderText({super.key, required this.text});

  @override
  Widget build(BuildContext context) {
    return Text(
      text,
      style: const TextStyle(
        color: Color.fromRGBO(13, 37, 60, 1),
        fontSize: 27,
        fontWeight: FontWeight.w100,
        fontStyle: FontStyle.italic,
        fontFamily: "Urbanist",
      ),
    );
    ;
  }
}

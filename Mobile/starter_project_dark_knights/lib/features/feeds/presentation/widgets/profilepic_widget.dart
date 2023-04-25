import 'package:flutter/material.dart';

class Profilepic extends StatelessWidget {
  const Profilepic({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    return CircleAvatar(
      backgroundImage: const AssetImage("../../../assets/images/do.jpg"),
      radius: 23,
      child: Center(
          child: Container(
        height: 40,
        decoration: BoxDecoration(
            color: Colors.white.withOpacity(0),
            shape: BoxShape.circle,
            border: Border.all(color: Colors.white, width: 2)),
      )),
    );
  }
}

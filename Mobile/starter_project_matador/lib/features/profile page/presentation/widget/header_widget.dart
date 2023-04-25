import 'package:flutter/material.dart';

class ProfileText extends StatelessWidget {

  const ProfileText({super.key});

  @override
  Widget build(BuildContext context) {
    return const Padding(
      padding: EdgeInsets.fromLTRB(30, 15, 0, 0),
      child: Text(
        "Profile",
        style: TextStyle(
          fontFamily: "Urbanist", 
            fontSize: 22, color: Colors.black, fontWeight: FontWeight.w600),
      ),
    );
  }
}

class IconHeader extends StatelessWidget {
  const IconHeader({super.key});

  @override
  Widget build(BuildContext context) {
    return const Icon(
      Icons.more_horiz,
      color: Colors.black,
    );
  }
}

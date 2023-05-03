import 'package:dark_knights/core/utils/colors.dart';
import 'package:flutter/material.dart';

class ProfilePic extends StatelessWidget {
  const ProfilePic({
    super.key,
  });

  @override
  Widget build(BuildContext context) {
    final screenWidth = MediaQuery.of(context).size.width;
    return CircleAvatar(
      backgroundImage: const AssetImage("assets/images/profile_pic.jpg"),
      radius: screenWidth * 0.05,
      child: Center(
          child: Container(
        height: screenWidth * 0.09,
        decoration: BoxDecoration(
            color: whiteColor.withOpacity(0),
            shape: BoxShape.circle,
            border: Border.all(color: whiteColor, width: 2)),
      )),
    );
  }
}

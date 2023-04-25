import 'package:flutter/material.dart';

import '../widget/header_widget.dart';
import '../widget/posts_widget.dart';
import '../widget/profile_description_widget.dart';
import '../widget/status_card_widget.dart';


class Profile extends StatefulWidget {
  const Profile({super.key});

  @override
  State<Profile> createState() => _ProfileState();
}

class _ProfileState extends State<Profile> {
  @override
  Widget build(BuildContext context) {
    var screenWidth = MediaQuery.of(context);
    return Scaffold(
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.fromLTRB(30, 15, 0, 10),
            child: Row(
              children: [
                const ProfileText(),
                SizedBox(width: screenWidth.size.width * 0.7),
                const IconHeader()
              ],
            ),
          ),

          Stack(
              alignment: Alignment.bottomCenter,
              clipBehavior: Clip.none,
              children: [
                Profile_description(),
                //the first part of the stack ends here

                Positioned(
                    bottom: -25,
                    left: screenWidth.size.width * 0.08,
                    right: screenWidth.size.width * 0.08,
                    child: StatusCard()),
              ]),

          //the second half of the page starts here
          Expanded(
            child: ListView(
              physics: NeverScrollableScrollPhysics(),
              children: const [
                Padding(
                    padding: EdgeInsets.fromLTRB(0, 50, 0, 0), 
                    child: Posts()),
                // the first card
                Padding(
                    padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
                    child: Second_post())
              ],
            ),
          )
        ],
      ),
    );
  }
}

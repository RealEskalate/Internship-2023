import 'package:flutter/material.dart';

import '../widget/header.dart';
import '../widget/posts.dart';
import '../widget/profile_description.dart';
import '../widget/status_card.dart';


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
            child: Container(
            
              child: ListView(
                // physics: NeverScrollableScrollPhysics(),
                children: [
                  Padding(
                    padding: const EdgeInsets.fromLTRB(0, 80, 0, 0),
                    child: Card(
                      child: Row(
                        children: [
                          const Padding(
                            padding: EdgeInsets.fromLTRB(30, 10, 0, 10),
                            child: Text(
                              'My Posts',
                              style: TextStyle(fontSize: 18, fontWeight: FontWeight.w600),
                            ),
                          ),
                          SizedBox(width: screenWidth.size.width * 0.55),
                          const Icon(
                            Icons.grid_view,
                            color: Color.fromARGB(255, 6, 90, 159),
                          ),
                          SizedBox(width: 30),
                          const Icon(
                            Icons.toc,
                            color: Colors.grey,
                            size: 30,
                          ),
                        ],
                      ),
                                ),
                  ),
            
                  const PostCard(titleText: 'BIG DATA                                  ', 
                  description: 'Why Big Data Needs Thick Data?',
                   postImage: 'assets/images/laser.jpg',),
                  // the first card
                  const Padding(
                      padding: EdgeInsets.fromLTRB(0, 10, 0, 0),
                      child: PostCard(titleText: 'UX DESIGN                                  ',
                       description: 'Why Big Data Needs Thick Data?',
                        postImage: 'assets/images/board.jpg',)
                      )
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}

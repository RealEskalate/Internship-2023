import 'package:flutter/material.dart';


import '../../../../core/utils/colors.dart';
import '../widgets/blue_card.dart';
import '../widgets/post_display.dart';
class ProfilePage extends StatefulWidget {
  const ProfilePage({super.key, required this.title});

  final String title;

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final screenWidth =  MediaQuery.of(context).size.width;
    final textSize =  MediaQuery.textScaleFactorOf(context);
    return SafeArea(
      child: Scaffold(
          backgroundColor:scaffoldBackground,
          body: SingleChildScrollView(
            child: Column(children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Padding(
                    padding: EdgeInsets.only(
                        top: screenHeight * 0.02),
                    child: Text("Profile",
                        style: TextStyle(
                            fontSize:
                                22 * textSize,
                            fontWeight: FontWeight.w600,
                            fontFamily: 'Urbanist')),
                  ),
                  SizedBox(width: screenWidth * 0.06),
                  Icon(Icons.more_horiz)
                ],
              ),
              Padding(
                padding:  EdgeInsets.fromLTRB(screenWidth * 0.1, screenHeight * 0.01,screenWidth * 0.1, 55.0),
                child: Stack(
                  clipBehavior: Clip.none,
                  children: [
                    Card(
                        shape: RoundedRectangleBorder(
                            borderRadius: BorderRadius.circular(30)),
                        child: Padding(
                            padding: EdgeInsets.all(screenHeight * 0.009),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Padding(
                                  padding: EdgeInsets.all(screenHeight * 0.02),
                                  child: Row(
                                    mainAxisAlignment: MainAxisAlignment.start,
                                    children: [
                                      Container(
                                        height:
                                            screenHeight *
                                                0.11,
                                        width:
                                            MediaQuery.of(context).size.width *
                                                0.22,
                                        decoration: BoxDecoration(
                                          border: Border.all(
                                              //<-- SEE HERE
                                              width: screenWidth * 
                                                  0.007,
                                              color: Color.fromARGB(
                                                  255, 39, 176, 169)),
                                          borderRadius:
                                              BorderRadius.circular(30),
                                        ),
                                        child: Padding(
                                          padding: EdgeInsets.all(screenHeight * 0.008),
                                          child: ClipRRect(
                                            borderRadius:
                                                BorderRadius.circular(20),
                                            child: Image.network(
                                                "https://media.istockphoto.com/photos/smiling-indian-man-looking-at-camera-picture-id1270067126?b=1&k=20&m=1270067126&s=612x612&w=0&h=tcabRaVlA0bsZhWCDBXxC1IYuGnh7_VuramO-vJ5jRs=",
                                                fit: BoxFit.cover),
                                          ),
                                        ),
                                      ),
                                      SizedBox(width: screenWidth * 0.06),
                                      Column(
                                        children: [
                                          Text("@Joviedan",style: TextStyle(
                        fontSize: 14.0 * MediaQuery.textScaleFactorOf(context),
                        fontWeight: FontWeight.w900,
                        color: secondaryTextColor,
                        fontFamily: 'Poppins'
                      ),),
                                          SizedBox(height: screenHeight * 0.005),
                                          Text("Jovi Daniel",style: TextStyle(
                        fontSize: 18.0 * textSize,
                        fontWeight: FontWeight.w100,
                        fontStyle: FontStyle.italic,
              
                        color:secondaryTextColor,
                        fontFamily: 'Urbanist'
                      ),),
                                          SizedBox(height: screenHeight * 0.009),
                                          Text("Ux Designer",style: TextStyle(
                        fontSize: 16.0 * textSize,
                        fontWeight: FontWeight.w100,
                        color: secondaryColor,
                        fontStyle: FontStyle.italic,
                        fontFamily: 'Urbanist'
                      ),),
                                        ],
                                      )
                                    ],
                                  ),
                                ),
                                Padding(
                                  padding:
                                       EdgeInsets.fromLTRB(screenWidth * 0.04, screenHeight * 0.01, 0, screenHeight * 0.006),
                                  child: Text("About me",style: TextStyle(
                        fontSize: 16.0 *textSize,
                        fontWeight: FontWeight.w300,
                        color:primaryTextColor,
                        fontStyle: FontStyle.italic,
                        fontFamily: 'Urbanist'
                      ),),
                                ),
                                Padding(
                                  padding:  EdgeInsets.fromLTRB(
                                      screenWidth * 0.04 ,screenHeight * 0.008,  screenWidth * 0.05, screenHeight * 0.087),
                                  child: Text(
                                      'Madison blackstone is the director of  '
                                      'user experience design with '
                                      'experience managing global teams.',style: TextStyle(
                        fontSize: 14 * textSize,
                        fontWeight: FontWeight.w100,
                        color: secondaryTextColor,
                        fontStyle: FontStyle.italic,
                        fontFamily: 'Urbanist'
                      ),),
                                ),
                              ],
                            ))),
                    StatusCard()
                  ],
                ),
              ),
              PostDisplay()
            ]),
          )),
    );
  }
}

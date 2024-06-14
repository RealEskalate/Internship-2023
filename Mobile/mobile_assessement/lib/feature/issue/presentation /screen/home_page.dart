
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import '../bloc/issue_bloc.dart';
import '../bloc/issue_event.dart';
import '../bloc/issue_state.dart';

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    final screenHeight = MediaQuery.of(context).size.height;
    final fem = 2.1; // assign a value to fem
    final ffem = 2; // assign a value to ffem

    return Scaffold(
      body: Container(
  // issuedetailsakb (2:120)
  padding:  EdgeInsets.fromLTRB(8*fem, 41.88*fem, 8*fem, 131*fem),
  width:  double.infinity,
  decoration:  BoxDecoration (
    color:  Color(0xfffdfeff),
  ),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // materialsymbolsarrowbackrounde (2:121)
  margin:  EdgeInsets.fromLTRB(21.33*fem, 0*fem, 0*fem, 29.87*fem),
  width:  20.77*fem,
  height:  20.25*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // joinhackathoncompetitionprepar (2:123)
  margin:  EdgeInsets.fromLTRB(21*fem, 0*fem, 0*fem, 26*fem),
  constraints:  BoxConstraints (
    maxWidth:  361*fem,
  ),
  child:  
Text(
  'Join Hackathon competition prepared for all African students ',
  style:  TextStyle (
   
    fontWeight:  FontWeight.w600,
    height:  1.5*ffem/fem,
    color:  Color(0xff000000),
  ),
),
),
Container(
  // useravatarvdateandtimenNo (2:124)
  margin:  EdgeInsets.fromLTRB(21*fem, 0*fem, 0*fem, 37*fem),
  width:  189.1*fem,
  height:  40*fem,
  child:  
Stack(
  children:  [
Positioned(
  // datetimegj5 (2:125)
  left:  44.1214904785*fem,
  top:  19*fem,
  child:  
Container(
  width:  144.98*fem,
  height:  15*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Center(
  // november2022oYo (2:126)
  child:  
Text(
  '12 November 2022 ',
  textAlign:  TextAlign.center,
  style:  TextStyle (
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xffababab),
  ),
),
),
Container(
  // autogroupfuptKX9 (Vn1aEx1wSiTN9TKYwvFUpT)
  padding:  EdgeInsets.fromLTRB(3*fem, 0*fem, 0*fem, 0*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // rectangle54Fvb (2:127)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 4*fem, 0*fem),
  width:  0.98*fem,
  height:  10*fem,
  decoration:  BoxDecoration (
    borderRadius:  BorderRadius.circular(2*fem),
    color:  Color(0xffababab),
  ),
),
Text(
  // amAnf (2:128)
  '12:08 am',
  style:  TextStyle (
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xffababab),
  ),
),
  ],
),
),
  ],
),
),
),
Positioned(
  // useravatarK9m (2:129)
  left:  0*fem,
  top:  0*fem,
  child:  
Container(
  width:  110.12*fem,
  height:  40*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // ellipse19EnX (2:131)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 5.87*fem, 0*fem),
  width:  39.25*fem,
  height:  40*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // bethslanderxTd (2:130)
  margin:  EdgeInsets.fromLTRB(0*fem, 3*fem, 0*fem, 0*fem),
  child:  
Text(
  'Beth Slander',
  style:  TextStyle (
    fontWeight:  FontWeight.w500,
    height:  1.5*ffem/fem,
    color:  Color(0xff000000),
  ),
),
),
  ],
),
),
),
  ],
),
),
Container(
  // horemipsumdolorsitametconsecte (2:132)
  margin:  EdgeInsets.fromLTRB(21*fem, 0*fem, 0*fem, 18*fem),
  constraints:  BoxConstraints (
    maxWidth:  369*fem,
  ),
  child:  
Text(
  'Horem ipsum dolor sit amet, consectetur adipiscing elit. Etiam eu turpis molestie, dictum est a, mattis tellus. Sed dignissim, metus nec fringilla accumsan, risus sem sollicitudin lacus, ut interdum tellus elit sed risus. Maecenas eget condimentum velit, sit amet feugiat lectus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Praesent auctor purus luctus enim egestas, ac scelerisque ante pulvinar. Donec ut rhoncus ex. Suspendisse ac rhoncus nisl, eu tempor urna. Curabitur vel bibendum lorem. Morbi convallis convallis diam sit amet lacinia. Aliquam in elementum tellus.',
  style:  TextStyle (
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff646464),
  ),
),
),
Container(
  // resourceswD5 (2:134)
  margin:  EdgeInsets.fromLTRB(24*fem, 0*fem, 0*fem, 27*fem),
  child:  
Text(
  'Resources',
  style:  TextStyle (
    fontSize:  16,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff000000),
  ),
),
),
Container(
  // resourcesgroupExs (2:135)
  margin:  EdgeInsets.fromLTRB(16*fem, 0*fem, 0*fem, 22*fem),
  width:  347*fem,
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // filetile1B7R (2:136)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 24*fem),
  width:  double.infinity,
  height:  55*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // iconareauZD (2:137)
  padding:  EdgeInsets.fromLTRB(11*fem, 11*fem, 10.15*fem, 10.15*fem),
  height:  double.infinity,
  decoration:  BoxDecoration (
    color:  Color(0xfff6f6fc),
    borderRadius:  BorderRadius.circular(10*fem),
  ),
  child:  
Center(
  // googledocs3QX (2:139)
  child:  
SizedBox(
  width:  33.85*fem,
  height:  33.85*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
),
),
Container(
  // autogroupsfe3yZ5 (Vn1ab2GpqJit8x8gS3sfe3)
  padding:  EdgeInsets.fromLTRB(36*fem, 0*fem, 0*fem, 0*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // autogroupl8pdvDR (Vn1aVGwQFeGnCTufjWL8PD)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 81*fem, 5*fem),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // introductiondocrsm (2:140)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 5*fem),
  child:  
Text(
  'Introduction.doc',
  style:  TextStyle (
    fontSize:  16,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff565656),
  ),
),
),
Text(
  // apr927pmzDH (2:142)
  '18 Apr 9:27pm',
  style:  TextStyle (
    fontSize:  14,
    fontWeight:  FontWeight.w500,
    height:  1.5*ffem/fem,
    color:  Color(0xff8e8e8e),
  ),
),
  ],
),
),
Container(
  // kbXyu (2:141)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 4*fem),
  child:  
Text(
  '128 KB',
  style:  TextStyle (
   
    fontSize:  14,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff565656),
  ),
),
),
  ],
),
),
  ],
),
),
Container(
  // filetile2Tcf (2:143)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 2*fem, 0*fem),
  width:  double.infinity,
  height:  55*fem,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // iconareaPmD (2:144)
  padding:  EdgeInsets.fromLTRB(11*fem, 11*fem, 10.15*fem, 10.15*fem),
  height:  double.infinity,
  decoration:  BoxDecoration (
    color:  Color(0xfff6f6fc),
    borderRadius:  BorderRadius.circular(10*fem),
  ),
  child:  
Center(
  // googledocs8D1 (2:146)
  child:  
SizedBox(
  width:  33.85*fem,
  height:  33.85*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
),
),
Container(
  // autogroupqevyruh (Vn1awgM5D7JBHLZbNzQeVy)
  padding:  EdgeInsets.fromLTRB(37*fem, 0*fem, 0*fem, 0*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // autogroupf6zf11u (Vn1arMAd3jvVJv4iJAf6zF)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 17*fem, 5*fem),
  child:  
Column(
  crossAxisAlignment:  CrossAxisAlignment.start,
  children:  [
Container(
  // qualificationcriteriadocYnX (2:147)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 5*fem),
  child:  
Text(
  'Qualification criteria.doc',
  style:  TextStyle (
    fontSize:  16,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff565656),
  ),
),
),
Text(
  // apr927pmURH (2:149)
  '18 Apr 9:27pm',
  style:  TextStyle (
    fontWeight:  FontWeight.w500,
    height:  1.5*ffem/fem,
    color:  Color(0xff8e8e8e),
  ),
),
  ],
),
),
Container(
  // mbpEF (2:148)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 0*fem, 4*fem),
  child:  
Text(
  '1.2 MB',
  style:  TextStyle (
    fontSize:  14,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff565656),
  ),
),
),
  ],
),
),
  ],
),
),
  ],
),
),
Container(
  // interactionssectionwZm (2:150)
  padding:  EdgeInsets.fromLTRB(18*fem, 14*fem, 21*fem, 13*fem),
  width:  double.infinity,
  height:  60*fem,
  decoration:  BoxDecoration (
    color:  Color(0xffffffff),
    borderRadius:  BorderRadius.circular(11*fem),
  ),
  child:  
Container(
  // contentTHD (I2:150;23:120)
  padding:  EdgeInsets.fromLTRB(3.5*fem, 1*fem, 0*fem, 0*fem),
  width:  double.infinity,
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // pharrowcircleupthinnaP (I2:150;23:126)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 10.5*fem, 2*fem),
  width:  25*fem,
  height:  25*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // HX9 (I2:150;23:121)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 33.5*fem, 1*fem),
  child:  
Text(
  '183',
  style:  TextStyle (
    
    fontWeight:  FontWeight.w500,
    height:  1.5*ffem/fem,
    color:  Color(0xff1e5c88),
  ),
),
),
Container(
  // pharrowcircleupthincJX (I2:150;23:128)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 114.5*fem, 2*fem),
  width:  25*fem,
  height:  25*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // comments81y (I2:150;23:122)
  padding:  EdgeInsets.fromLTRB(4.26*fem, 5*fem, 0*fem, 4.27*fem),
  height:  double.infinity,
  child:  
Row(
  crossAxisAlignment:  CrossAxisAlignment.center,
  children:  [
Container(
  // basilcommentoutline4wD (I2:150;23:124)
  margin:  EdgeInsets.fromLTRB(0*fem, 0*fem, 12.33*fem, 0*fem),
  width:  23.4*fem,
  height:  22.73*fem,
  child:  
Image(
  image: AssetImage('assets/images/image1.jpg'),  
  
  width: 24*fem,
  height: 24*fem,
)
),
Container(
  // commentsnsD (I2:150;23:123)
  margin:  EdgeInsets.fromLTRB(0*fem, 0.27*fem, 0*fem, 0*fem),
  child:  
Text(
  '24 Comments',
  style:  TextStyle (
    fontSize:  14,
    fontWeight:  FontWeight.w400,
    height:  1.5*ffem/fem,
    color:  Color(0xff949494),
  ),
),
),
  ],
),
),
  ],
),
),
),
  ],
),
),);}}
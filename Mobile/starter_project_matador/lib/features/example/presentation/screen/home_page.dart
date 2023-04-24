import 'package:flutter/material.dart';
import 'package:matador/core/constants/colors.dart';
import 'package:matador/core/utils/real_pixel_to_logical_pixel.dart';
import 'package:matador/features/example/presentation/widgets/home_page/appbarr_title.dart';
import 'package:matador/features/example/presentation/widgets/home_page/menu_icon.dart';
import 'package:matador/features/example/presentation/widgets/home_page/profile_avatar.dart';

class HomePage extends StatelessWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: scaffoldBackGroundColor,
      appBar: AppBar(
        // To remove default elevation from AbbBarr
        bottomOpacity: 0.0,
        elevation: 0.0,
        scrolledUnderElevation: 0,
        toolbarHeight: convertPixelToScreenHeight(context, 45),
        backgroundColor: scaffoldBackGroundColor,

        leading: const MenuIcon(),
        title: const AppBarrTitle(),
        actions: const [
          ProfileAvatar(),
        ],
      ),
    );
    // }
  }
}

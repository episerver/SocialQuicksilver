Quicksilver 
===========
[![License](http://img.shields.io/:license-apache-blue.svg?style=flat-square)](http://www.apache.org/licenses/LICENSE-2.0.html)

This repository demonstrates the use of Episerver Social in an e-commerce scenario. It contains a clone of the Episerver starter site *Quicksilver* that has been modified to use Episerver Social to add product reviews.

A full walkthrough of this implementation can be found on the Episerver Social blog:
http://world.episerver.com/blogs/chris-banner/dates/2017/3/building-product-reviews-with-episerver-social/

What's Inside?
------------
* **Product Reviews**
  * Product reviews have been added to product pages appearing within the site, allowing visitors to rate and comment on products. It demonstrates a combination of Episerver Social's Comments and Ratings features as well as the platform's composition and modeling capabilities.

Episerver Social Configuration
------------
1. In Visual Studio, open the **web.config** file found in the root of the **EPiServer.Reference.Commerce.Site** project.
2. Update this file with your Episerver Social configuration, as described in the [Getting Connected](http://world.episerver.com/documentation/developer-guides/social/social_platform-overview/Installing-Episerver-Social/#GettingConnected) section of the developer guide.

QuickSilver Setup
------------
For information regarding the architecture, implementation, and installation of QuickSilver, please see the [readme maintained in episerver/QuickSilver](https://github.com/episerver/Quicksilver). 
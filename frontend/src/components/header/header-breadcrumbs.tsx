import React from "react";
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from "@/components/ui/breadcrumb";
import { Link, useLocation } from "react-router";
import { ROUTES } from "@/config/routes";

export const HeaderBreadcrumbs: React.FC = () => {
  const location = useLocation();

  const paths = location.pathname.split("/").filter(Boolean);

  return (
    <Breadcrumb>
      <BreadcrumbList>
        {paths.length > 0 ? (
          <BreadcrumbItem className="hidden md:block">
            <BreadcrumbLink asChild>
              <Link to={ROUTES.appRoute}>Home</Link>
            </BreadcrumbLink>
          </BreadcrumbItem>
        ) : (
          <BreadcrumbItem className="hidden md:block">
            <BreadcrumbPage>Home</BreadcrumbPage>
          </BreadcrumbItem>
        )}

        {paths.length > 0 && <BreadcrumbSeparator className="hidden md:block" />}

        {paths.map((path, index) => {
          const isLast = index === paths.length - 1;
          const href = `/${paths.slice(0, index + 1).join("/")}`;

          return (
            <>
              <BreadcrumbItem key={href}>
                {isLast ? (
                  <BreadcrumbPage className="capitalize">{path}</BreadcrumbPage>
                ) : (
                  <BreadcrumbLink asChild className="hidden md:block capitalize">
                    <Link to={href}>{path}</Link>
                  </BreadcrumbLink>
                )}
                {!isLast && <BreadcrumbSeparator className="hidden md:block" />}
              </BreadcrumbItem>
            </>
          );
        })}
      </BreadcrumbList>
    </Breadcrumb>
  );
};

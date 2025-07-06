import { Calculator, Plus, Minus, Divide, Radical, X, ChevronUp, Home } from "lucide-react";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import { ModeToggle } from "@/components/theme/mode-toggle";
import { ROUTES } from "@/config/routes";
import { NavLink, useLocation } from "react-router";

const baseItems = [
  {
    title: "Home page",
    url: ROUTES.appRoute,
    icon: Home,
  },
];

const calculatorItems = [
  {
    title: "Expression",
    url: ROUTES.expression.page,
    icon: Calculator,
  },
  {
    title: "Sum",
    url: ROUTES.sum.page,
    icon: Plus,
  },
  {
    title: "Subtract",
    url: ROUTES.subtract.page,
    icon: Minus,
  },
  {
    title: "Multiply",
    url: ROUTES.multiply.page,
    icon: X,
  },
  {
    title: "Divide",
    url: ROUTES.divide.page,
    icon: Divide,
  },
  {
    title: "Pow",
    url: ROUTES.pow.page,
    icon: ChevronUp,
  },
  {
    title: "Sqrt",
    url: ROUTES.sqrt.page,
    icon: Radical,
  },
];

export function AppSidebar() {
  const location = useLocation();
  const currentPath = location.pathname;

  return (
    <Sidebar collapsible="icon">
      <SidebarContent>
        <SidebarGroup>
          <SidebarGroupLabel>Base</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {baseItems.map((item) => (
                <SidebarMenuItem key={item.title}>
                  <SidebarMenuButton asChild isActive={currentPath === item.url}>
                    <NavLink to={item.url}>
                      <item.icon />
                      <span>{item.title}</span>
                    </NavLink>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>

        <SidebarGroup>
          <SidebarGroupLabel>Calculators</SidebarGroupLabel>
          <SidebarGroupContent>
            <SidebarMenu>
              {calculatorItems.map((item) => (
                <SidebarMenuItem key={item.title}>
                  <SidebarMenuButton asChild isActive={currentPath === item.url}>
                    <NavLink to={item.url}>
                      <item.icon />
                      <span>{item.title}</span>
                    </NavLink>
                  </SidebarMenuButton>
                </SidebarMenuItem>
              ))}
            </SidebarMenu>
          </SidebarGroupContent>
        </SidebarGroup>
      </SidebarContent>

      <SidebarFooter className="items-center">
        <ModeToggle />
      </SidebarFooter>
    </Sidebar>
  );
}
